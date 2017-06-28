using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class ContactController : ApiController
    {
		Contact[] contacts = new Contact[]
			{
				new Contact(){ ID=1,Age=23,Birthday=Convert.ToDateTime("1991-12-20"),Name="张三",Sex="男"},
				new Contact(){ ID=2,Age=33,Birthday=Convert.ToDateTime("1992-12-20"),Name="张三",Sex="男"},
				new Contact(){ ID=3,Age=13,Birthday=Convert.ToDateTime("1993-12-20"),Name="张三",Sex="女"},
				new Contact(){ ID=4,Age=53,Birthday=Convert.ToDateTime("1994-12-20"),Name="张三",Sex="女"},
				new Contact(){ ID=5,Age=63,Birthday=Convert.ToDateTime("1995-12-20"),Name="张三",Sex="男"},
				new Contact(){ ID=6,Age=23,Birthday=Convert.ToDateTime("1996-12-20"),Name="张三",Sex="女"},
			};
		/// <summary>
		/// /api/contact
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Contact> GetListAll()
		{
			return contacts;
		}

		/// <summary>
		/// /api/contact/id
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public Contact GetContactByID(int ID)
		{
			//Contact contact = contacts.FirstOrDefault<Contact>(item => item.ID == ID);
			Contact contact = contacts.FirstOrDefault(item => item.ID == ID);
			if (contact == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return contact;
		}

		/// <summary>
		/// 根据性别查询
		/// /api/Contact?sex="女"
		/// </summary>
		/// <param name="sex"></param>
		/// <returns></returns>
		public IEnumerable<Contact> GetListBySex(string sex)
		{
			return contacts.Where(s => s.Sex == sex); 
		}
    }
}
