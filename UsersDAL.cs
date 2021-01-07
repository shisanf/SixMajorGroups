using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;
using Newtonsoft.Json;

namespace DAL
{
   public  class UsersDAL
    {
        //登录
        public Users GetUsers(string uname,string pwd)
        {
            string sql = $"select * from Users where UserName='{uname}' and PassWord='{pwd}'";
            DataTable dt = DBHelper.GetDataTable(sql);
            string str = JsonConvert.SerializeObject(dt);
            List<Users> users = JsonConvert.DeserializeObject<List<Users>>(str);
            return users.FirstOrDefault();
        }
        //绑定下拉
        public List<Users> XlUsers()
        {
            string sql = "select *from Users";
            DataTable dt = DBHelper.GetDataTable(sql);
            string str = JsonConvert.SerializeObject(dt);
            List<Users> users = JsonConvert.DeserializeObject<List<Users>>(str);
            return users;
        }
        //绑定下拉编号
        public List<Car> XlCar()
        {
            string sql = "select *from Car";
            DataTable dt = DBHelper.GetDataTable(sql);
            string str = JsonConvert.SerializeObject(dt);
            List<Car> users = JsonConvert.DeserializeObject<List<Car>>(str);
            return users;
        }
        //显示
        public List<Car> GetCars(string cname)
        {
            string sql = "select *from Car where 1=1";
            if(!string.IsNullOrEmpty(cname))
            {
                sql += $" and CarC like '%{cname}%'";
            }
            DataTable dt = DBHelper.GetDataTable(sql);
            string str = JsonConvert.SerializeObject(dt);
            List<Car> users = JsonConvert.DeserializeObject<List<Car>>(str);
            return users;
        }
        //删除
        public int Delete(int id)
        {
            string sql = $"delete from Car where CId='{id}'";
            return DBHelper.CRUD(sql);
        }
        //批量删除
        public int Del(string id)
        {
            string sql = $"delete from Car where CId in ({id})";
            return DBHelper.CRUD(sql);
        }
        //添加
        public int Add(Car c)
        {
            string sql = $"insert into Car values('{c.CarC}','{c.CarBegin}','{c.CarEnd}','{c.BeginTime}','{c.EndTime}','{c.Price}','{c.BeiZ}')";
            return DBHelper.CRUD(sql);
        }
        //反填
        public Car GetT(int id)
        {
            string sql = $"select * from Car where CId='{id}'";
            DataTable dt = DBHelper.GetDataTable(sql);
            string str = JsonConvert.SerializeObject(dt);
            List<Car> users = JsonConvert.DeserializeObject<List<Car>>(str);
            return users.FirstOrDefault();
        }
        //修改
        public int Update(Car c)
        {
            string sql = $"update Car set CarC='{c.CarC}',CarBegin='{c.CarBegin}',CarEnd='{c.CarEnd}',BeginTime='{c.BeginTime}',EndTime='{c.EndTime}',Price='{c.Price}' where CId={c.CId}";
            return DBHelper.CRUD(sql);
        }
        //导入数据方法
        public int ImportData(string str)
        {
            return DBHelper.CRUD(str);
        }
    }
}
