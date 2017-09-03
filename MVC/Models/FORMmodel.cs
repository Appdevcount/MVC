using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace MVC.Models
{
    public class FORMmodel
    {
     
        public string UName { get; set; }
        public string Password { get; set; }

        public List<SelectListItem> DDMobileBrand
        {
            get
            {
                List<SelectListItem> DDMobileBrand = new List<SelectListItem>();
                DDMobileBrand.Add(new SelectListItem { Text = "a", Value = "av" });
                DDMobileBrand.Add(new SelectListItem { Text = "b", Value = "bv" });


                return DDMobileBrand;
            }
            //set;
        }

        public  SelectList DDMobilBrandDB
        {
            get;
            //{
            //    var list =new List<DDMobileBrandModelDB>();
            //    SqlConnection cn = new SqlConnection("Data Source=IKW-PC;Initial Catalog=VASTest;Integrated Security=True");
            //        cn.Open();
            //    using (SqlCommand cmd = new SqlCommand("select ID,NAME FROM MVCDDMobileBrands", cn))
            //    {
            //        using (SqlDataReader rdr = cmd.ExecuteReader())
            //        {
            //            while(rdr.Read())
            //            {
            //                //DDMobileBrandModelDB d1 = new DDMobileBrandModelDB { ID = rdr.GetInt32(0).ToString(), Name = rdr.GetString(1) };
            //                //list.Add(d1);// (new DDMobileBrandModelDB { ID = rdr.GetInt32(0).ToString(), Name = rdr.GetString(1) });
            //                list.Add(new DDMobileBrandModelDB { ID = rdr.GetInt32(0).ToString(), Name = rdr.GetString(1) });

            //            }
            //            SelectList dds = new SelectList(list, "ID", "Name");
            //            return dds;// new SelectList(list, "ID", "Name");
            //        }
            //    }
            //    cn.Close();
            //}
            set;
        }

        //List<CHKMobileBrandModel> list = new List<CHKMobileBrandModel>();
        public List<CHKMobileBrandModel> CHKMobileBrandlist
        {
            get
            {
                //    //CHKMobileBrandModel cm = new CHKMobileBrandModel();
                //    //cm.Add(new CHKMobileBrandModel { id = 1, name = "chk1", @checked = true });
                //    //cm.Add(new CHKMobileBrandModel { id = 2, name = "chk2", @checked = true });

                //    //List<CHKMobileBrandModel> CHKMobileBrandlist = new List<CHKMobileBrandModel>();
                //    //CHKMobileBrandlist.Add(new CHKMobileBrandModel { id = 1, name = "CHK1", @checked = false });
                //    //CHKMobileBrandlist.Add(new CHKMobileBrandModel { id = 2, name = "CHK2", @checked = false });
                //    //return CHKMobileBrandlist;

                var list = new List<CHKMobileBrandModel>();
                SqlConnection cn = new SqlConnection("Data Source=IKW-PC;Initial Catalog=VASTest;Integrated Security=True");
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("select chkid,chkname,chkchecked FROM MVCchkMobileBrands", cn))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(new CHKMobileBrandModel { id = rdr.GetInt32(0), name = rdr.GetString(1), @checked = rdr.GetBoolean(2) });
                        }
                        return list;
                    }
                }
                cn.Close();
            }
            //set { }
            //{

            //    //    //this.CC.@checked = value;

            //    //    //CHKMobileBrandModel schk=this.list.Select(i=>i.id==value)

            //    //    this.list = value;

            //}


        }
        //CHKMobileBrandModel CC;
        public List<RBMobileBrandModel> RBMobileBrand
        {
            get
            {

                //List<RBMobileBrandModel> RBMobileBrand = new List<RBMobileBrandModel>();
                //RBMobileBrand.Add(new RBMobileBrandModel { ID = 1, NAME = "RB1"});
                //RBMobileBrand.Add(new RBMobileBrandModel { ID = 2, NAME = "RB2" });
                //return RBMobileBrand;

                var list = new List<RBMobileBrandModel>();
                SqlConnection cn = new SqlConnection("Data Source=IKW-PC;Initial Catalog=VASTest;Integrated Security=True");
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("select ID,NAME FROM MVCDDMobileBrands", cn))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(new RBMobileBrandModel { ID = rdr.GetInt32(0), NAME = rdr.GetString(1) });
                        }
                        return list;
                    }
                }
                cn.Close();
            }
            //set;
        }
        public string SelectedDepartmentDD { get; set; }

        public string SelectedDepartmentRB { get; set; }
    }
    public class CHKMobileBrandModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool @checked { get; set; }

    }
    public class RBMobileBrandModel
    {
        public int ID { get; set; }
        public string NAME { get; set; }
    }
    public class DDMobileBrandModelDB
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}