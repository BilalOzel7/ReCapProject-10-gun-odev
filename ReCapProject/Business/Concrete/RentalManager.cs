﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            if (entity.ReturnDate.Equals(new DateTime(0002, 02, 2)))
            {
                return new ErrorResult(Messages.ReturnDateCannotBeNull);
            }

            else if (entity.ReturnDate.Day - entity.RentDate.Day < 0)
            {
                return new ErrorResult(Messages.RentalDayLessThanZero);
            }

            var result = _rentalDal.GetAll().SingleOrDefault(x => x.CarId == entity.CarId);
            if (result == null)
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                if (result.ReturnDate != null)
                {
                    return new ErrorResult(Messages.RentalCarNotAvailable);
                }
                else
                {
                    _rentalDal.Add(entity);
                    return new SuccessResult(Messages.RentalAdded);
                }
            }
        }
        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());

        }
            public IDataResult<Rental> GetByID(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == Id));
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
