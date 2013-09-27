using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AliexpressEF.YiDa.Domain;
//using KeWeiOMS.NhibernateHelper;
using NHibernate;
using AliexpressEF.API;

namespace AliexpressEF.YiDa.Controllers
{
    public class AliOrderController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult OrderScanByQue()
        {
            return View();
        }

        public ActionResult OrderScanBySend()
        {
            return View();
        }

        public ActionResult QueList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Domain.AliOrderType obj)
        {
            base.Save<Domain.AliOrderType>(obj);
            return Json(new { IsSuccess = true });
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(int id)
        {
            Domain.AliOrderType obj = base.Get<Domain.AliOrderType>(id);
            return View(obj);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(Domain.AliOrderType obj)
        {

            base.Update<Domain.AliOrderType>(obj);
            return Json(new { IsSuccess = "true" });

        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {

            base.Delete<Domain.AliOrderType>(id);
            return Json(new { IsSuccess = "true" });
        }

        public JsonResult List(int page, int rows, string sort, string order, string search)
        {

            long total = 0;
            IList<Domain.AliOrderType> objList = base.PaggingList<Domain.AliOrderType>(rows * (page - 1), rows, sort, search, out total);
            string ids = "";
            foreach (var item in objList)
            {
                ids += item.Id + ",";
            }
            ids = ids.Trim(',');
            if (ids.Length > 0)
            {
                IList<AliOrderProductType> products = NSession.CreateQuery(" from AliOrderProductType where OId in(" + ids + ")").List<AliOrderProductType>();
                foreach (var item in objList)
                {
                    item.ProductList = products.Where(x => x.OId == item.Id).ToList<AliOrderProductType>();
                }

            }
            return Json(new { total = total, rows = objList });
        }

        public JsonResult Syn(int s)
        {
            if (s == 0)
            {
                IList<AliShopType> list = GetAll<AliShopType>();
                List<CountryType> countrys = GetAll<CountryType>().ToList<CountryType>();
                foreach (AliShopType shop in list)
                {
                    if (!string.IsNullOrEmpty(shop.RefreshToken))
                    {
                        if (!string.IsNullOrEmpty(shop.AccessToken))
                        {
                            TimeSpan ts = (DateTime.Now - shop.TokenUpdateOn);
                            if (ts.TotalHours > 8)
                            {
                                shop.AccessToken = AliUtil.GetAccessToken(shop.RefreshToken);
                                shop.TokenUpdateOn = DateTime.Now;
                                Update<AliShopType>(shop);
                            }

                            int page = 1; AliOrderListType aliOrderList = null;
                            do
                            {
                                aliOrderList = AliUtil.findOrderListQuery(shop.AccessToken, page, AliOrderStatus.WAIT_SELLER_SEND_GOODS);

                                foreach (OrderList foo in aliOrderList.orderList)
                                {
                                    AliexpressEF.API.AliOrderType o = AliUtil.findOrderById(shop.AccessToken, foo.orderId);
                                    Domain.AliOrderType order = new Domain.AliOrderType
                                    {
                                        OrderNo = foo.orderId,
                                        Status = "等待您发货",
                                        HasPrint = 0,
                                        HasMerger = 0,
                                        CurrencyCode = foo.payAmount.currencyCode,
                                        Amount = foo.payAmount.amount,

                                        BuyerId = o.buyerInfo.loginId,
                                        BuyerName = o.buyerSignerFullname,
                                        BuyerEmail = o.buyerInfo.email,

                                        RecipientCity = o.receiptAddress.city,
                                        RecipientName = o.receiptAddress.contactPerson,
                                        RecipientPhone = o.receiptAddress.phoneCountry + "-" + o.receiptAddress.phoneArea + "-" + o.receiptAddress.phoneNumber,
                                        RecipientPostCode = o.receiptAddress.zip,
                                        RecipientStreet = o.receiptAddress.detailAddress + " " + o.receiptAddress.address2,
                                        RecipientProvince = o.receiptAddress.province,
                                        RecipientCountry = o.receiptAddress.country,
                                        RecipientTel = o.receiptAddress.mobileNo,

                                        GenerateOn = AliUtil.GetAliDate(o.gmtCreate),
                                        SendOn = DateTime.Now,

                                        ShopId = shop.Id,
                                        ShopTitle = shop.ShopTitle,
                                        UId = shop.UId,
                                        LogisticType = foo.productList[0].logisticsServiceName
                                    };
                                    CountryType country =
                                       countrys.Find(
                                           p => p.CountryCode.ToUpper() == o.receiptAddress.country.ToUpper());
                                    if (country != null)
                                        order.RecipientCountry = country.ECountry;
                                    base.Save<Domain.AliOrderType>(order);
                                    foreach (ProductList fo in foo.productList)
                                    {
                                        order.OrderNote += fo.memo;
                                        AliOrderProductType product = new AliOrderProductType();
                                        product.SKU = fo.skuCode;
                                        product.ItemId = fo.productId;
                                        product.Qty = fo.productCount;
                                        product.Title = fo.productName;
                                        product.Price = fo.productUnitPrice.amount;
                                        product.OId = order.Id;
                                        product.ImgUrl = fo.productImgUrl;
                                        product.ItemUrl = fo.productSnapUrl;
                                        base.Save<Domain.AliOrderProductType>(product);
                                    }
                                    base.Update<Domain.AliOrderType>(order);
                                }
                                page++;
                            } while (aliOrderList.totalItem > (page - 1) * 50);
                        }
                    }
                }
            }
            return Json(new { IsSuccess = true });
        }
    }
}

