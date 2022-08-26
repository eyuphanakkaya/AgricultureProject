using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class NewsManager:INewsService
	{
		private readonly INewsDal _newsDal;

		public NewsManager(INewsDal newsDal)
		{
			_newsDal = newsDal;
		}

		public List<News> GetAll()
		{
			return _newsDal.GetAll();
		}

		public News GetById(int id)
		{
			return _newsDal.GetById(id);
		}

		public void TDelete(News t)
		{
			_newsDal.Delete(t);
		}

		public void TInsert(News t)
		{
			_newsDal.Insert(t);
		}

		public void TUpdate(News t)
		{
			_newsDal.Update(t);
		}
	}
}
