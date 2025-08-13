using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthorization.Controllers
{
    [Authorize]
    public class TestingController : Controller
    {
        [ClaimAuthorize]
        public ActionResult Action01() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action02() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action03() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action04() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action05() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action06() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action07() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action08() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action09() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action10() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action11() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action12() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action13() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action14() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action15() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action16() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action17() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action18() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action19() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action20() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action21() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action22() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action23() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action24() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action25() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action26() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action27() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action28() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action29() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action30() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action31() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action32() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action33() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action34() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action35() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action36() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action37() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action38() => View("Index");

        [ClaimAuthorize]
        public ActionResult Action39() => View("Index");

        [HttpPost, ClaimAuthorize]
        public ActionResult Action40() => View("Index");
    }
}