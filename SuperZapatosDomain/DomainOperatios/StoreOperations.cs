using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperZapatosModel;
using SuperZapatosModel.UnitOfWork;

namespace SuperZapatosDomain.BussinessLogic
{
    public class StoreOperations : IStoreOperations
    {
        private IUnitOfWork _unitOfWork;

        public StoreOperations(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Store> GetAll()
        {
            return _unitOfWork.Stores.GetAll().ToList() ;   
        }

        public Store FindById(int id)
        {
            return _unitOfWork.Stores.GetById(id);
        }

        public int Insert(Store store)
        {
            _unitOfWork.Stores.Insert(store);
            return _unitOfWork.Commit();
        }

        public int Delete(int id)
        {
            Store store =_unitOfWork.Stores.GetById(id);
            _unitOfWork.Stores.Delete(store);
            return _unitOfWork.Commit();
        }

        public int Update(Store store)
        {
            _unitOfWork.Stores.Update(store);
            return _unitOfWork.Commit();
        }

    }
}
