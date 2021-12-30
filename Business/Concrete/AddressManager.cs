using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;

        }
        [ValidationAspect(typeof(AddressValidator))]
        public IResult Add(Address address)
        {
            _addressDal.Add(address);
            return new SuccessResult(Messages.AddressAdded);

        }

        public IResult Delete(Address address)
        {
            _addressDal.Delete(address);
            return new SuccessResult(Messages.AddressDeleted);
        }

        public IDataResult<Address> GetById(int id)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(a => a.AddressId == id));
        }

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll());
        }

        public IResult Update(Address address)
        {
            _addressDal.Update(address);
            return new SuccessResult(Messages.AddressUpdated);
        }
        private IResult AddressAlreadyExists(int id)
        {
            var result=_addressDal.GetAll(a => a.AddressId == id).Any();
            if (result)
            {
                return new ErrorResult(Messages.AddressAlreadyExists);
            }
            return new SuccessResult();
            
        }
        
    }
}
