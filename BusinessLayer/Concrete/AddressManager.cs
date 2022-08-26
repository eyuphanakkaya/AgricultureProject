﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AddressManager:IAddressService
	{
		private readonly IAddressDal _addressDal;

		public AddressManager(IAddressDal addressDal)
		{
			_addressDal = addressDal;
		}

		public List<Address> GetAll()
		{
			return _addressDal.GetAll();
		}

		public Address GetById(int id)
		{
			return _addressDal.GetById(id);
		}

		public void TDelete(Address t)
		{
			_addressDal.Delete(t);
		}

		public void TInsert(Address t)
		{
			_addressDal.Insert(t);
		}

		public void TUpdate(Address t)
		{
			_addressDal.Update(t);
		}
	}
}
