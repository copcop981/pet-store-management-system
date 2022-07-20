using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;
using PetStoreManagement.DTO;

namespace PetStoreManagement.BLL
{
    internal class CategoryBLL
    {
        CategoryDAL categoryDAL = new CategoryDAL();

        internal List<CategoryDTO> getAllCategory()
        {
            return categoryDAL.getAllCategory();
        }

        internal List<ProductDTO> getProductByCategory(string cate)
        {
            return categoryDAL.getProductByCategory(cate);
        }
    }
}
