SessionPersistor is to incorporate Session into the Created Generic Identity for the user


        // GET: CustomAuthorize
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(CustomAccountViewModel cred)
        {
            CustomAccountModel cam = new CustomAccountModel();
            string UNAME = cred.acct.Username;
            string PWD = cred.acct.password;

            CustomAccount CA= cam.login(UNAME, PWD);
            //keeping it simple as much
            if (cam.login(UNAME, PWD) != null)
            {
                Session["Username"] = cred.acct.Username;
                SessionPersister.username = cred.acct.Username;
                return RedirectToAction("../IsysIraqUnsub/Subscibedlist");
            }
            ViewBag.InvalidCredential = "Invalid Username or Password ";
            return View("Login");
        }


        public ActionResult Logout()
        {
            SessionPersister.username = string.Empty;
            return RedirectToAction("Login");
        }


	public class CustomAccount

    {

        public string Username { get; set; }

        public string password { get; set; }

        //public string[] Roles { get; set; }

        //for simplicity purpose not creating Tables in DB now [User, Roles table in SQLServer] but will mention queries which can be mentioned

    }


	
    public class CustomAccountModel
    {

        public List<CustomAccount> Custaccts = new List<CustomAccount>();
        public CustomAccountModel()
        {
            Custaccts.Add(new CustomAccount
            {
                Username = "isys",
                password = "zain"//,
                //Roles = new string[] { "CANACCESS" }
            });

            //Custaccts.Add(new CustomAccount
            //{
            //    Username = "GSTL",
            //    password = "GSTL"//,
            //    //Roles = new string[] { "Seller", "Lead" }
            //});
        }
        public CustomAccount finduseracct(string uname)
        {
            CustomAccount useracct = Custaccts.Find(u => u.Username.Equals(uname));
            return useracct;
        }
        public CustomAccount login(string uname, string pwd)
        {
            CustomAccount useracctl = Custaccts.Find(u => u.Username.Equals(uname) && u.password.Equals(pwd));
            return useracctl;
        }

    }
