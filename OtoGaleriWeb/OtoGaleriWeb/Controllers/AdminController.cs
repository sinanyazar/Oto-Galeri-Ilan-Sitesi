using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using OtoGaleriWeb.Models;

namespace OtoGaleriWeb.Controllers
{
    public class AdminController : Controller
    {
        private List<Cities> _cityList = new List<Cities>();
        private List<Rates> _rateList = new List<Rates>();

        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.UserName = Session["ActiveUser"].ToString();

            #region Hava Durumu
            string url = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";

            WebClient wc = new WebClient();

            string xmlData = wc.DownloadString(url);

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xmlData);

            XmlNodeList cities = xDoc.DocumentElement.SelectNodes("sehirler");

            foreach (XmlNode item in cities)
            {
                if (item.SelectSingleNode("ili").InnerText == "İSTANBUL")
                {
                    try
                    {
                        Cities city = new Cities();

                        city.City = item.SelectSingleNode("ili").InnerText;
                        city.State = item.SelectSingleNode("Durum").InnerText;
                        city.MaxTemperature = int.Parse(item.SelectSingleNode("Mak").InnerText);

                        //if (item.SelectSingleNode("Min").InnerText != "" && int.Parse(item.SelectSingleNode("Min").InnerText) != 0)
                        //{
                        //    city.MinTemperature = int.Parse(item.SelectSingleNode("Min").InnerText);
                        //    _cityList.Add(city);
                        //    ViewBag.CityMinTemperature = _cityList.FirstOrDefault().MinTemperature + " ºC";
                        //}
                        //else
                        //{
                        //    _cityList.Add(city);
                        //}
                        _cityList.Add(city);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }

            ViewBag.City = _cityList.FirstOrDefault().City;
            ViewBag.CityState = _cityList.FirstOrDefault().State;
            ViewBag.CityMaxTemperature = _cityList.FirstOrDefault().MaxTemperature + " ºC";

            #endregion

            #region Merkez Bankası Kur
            string urlRate = "https://www.tcmb.gov.tr/kurlar/today.xml";

            string xmlRateData = wc.DownloadString(urlRate);

            xDoc.LoadXml(xmlRateData);

            XmlNodeList rates = xDoc.DocumentElement.SelectNodes("Currency");

            foreach (XmlNode item in rates)
            {
                if (item.SelectSingleNode("Isim").InnerText == "ABD DOLARI" || item.SelectSingleNode("Isim").InnerText == "EURO" || item.SelectSingleNode("CurrencyName").InnerText == "POUND STERLING")
                {
                    try
                    {
                        Rates rate = new Rates();
                        if (item.SelectSingleNode("CurrencyName").InnerText == "POUND STERLING")
                        {
                            rate.Name = item.SelectSingleNode("CurrencyName").InnerText;
                        }
                        else
                        {
                            rate.Name = item.SelectSingleNode("Isim").InnerText;
                        }
                        rate.ForexBuying = item.SelectSingleNode("ForexBuying").InnerText;
                        rate.ForexSelling = item.SelectSingleNode("ForexSelling").InnerText;

                        _rateList.Add(rate);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            ViewBag.RateList = _rateList.ToList();
            #endregion

            return View();
        }
    }
}