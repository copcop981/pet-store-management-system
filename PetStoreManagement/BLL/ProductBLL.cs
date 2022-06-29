using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;
using PetStoreManagement.DTO;

namespace PetStoreManagement.BLL
{
    internal class ProductBLL
    {
        ProductDAL productDAL = new ProductDAL();

        internal List<ProductDTO> getAllProduct(string search)
        {
            return productDAL.getAllProduct(search);
        }

        internal int addNewProduct(string pName, string pType, string pCategory, int pQuantity, int pPrice)
        {
            return productDAL.addNewProduct(pName, pType, pCategory, pQuantity, pPrice);
        }

        internal int updateProduct(string pName, string pType, string pCategory, int pQuantity, int pPrice, int pId)
        {
            return productDAL.updateProduct(pName, pType, pCategory, pQuantity, pPrice, pId);
        }

        internal int deleteProduct(int pId)
        {
            return productDAL.deleteProduct(pId);
        }
    }
}
