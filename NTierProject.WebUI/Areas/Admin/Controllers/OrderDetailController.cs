using NtierProject.SERVICE.Option;
using NTierProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

// TODO: 1  Detail listeleme, ekleme ve gücellemem yapılmamıştır

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: Admin/OrderDetail
        OrderService order = new OrderService();
        OrderDetailService orderDetail = new OrderDetailService();
        public ActionResult Index()
        {
            return View(orderDetail.GetActive());
        }

        public ActionResult Add()
        {
            return View(order.GetActive());
        }

        [HttpPost]
        public ActionResult Add(OrderDetail data)
        {
            data.ID = Guid.NewGuid();
            orderDetail.Add(data);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail od = orderDetail.GetById(id);
            if (od == null)
            {
                return HttpNotFound();
            }
            return View(od);
        }
  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            OrderDetail od = orderDetail.GetById(id);
            orderDetail.Remove(od);
            return RedirectToAction("Index");
        }
    }
}