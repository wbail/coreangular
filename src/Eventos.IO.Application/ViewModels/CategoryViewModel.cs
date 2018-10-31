using System;
using System.Collections.Generic;

namespace Eventos.IO.Application.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<CategoryViewModel> ListCategory()
        {
            var categoryList = new List<CategoryViewModel>()
            {
                new CategoryViewModel() { Id = new Guid("8a970832-8d16-468f-8806-b68085bded3a"), Name = "X"},
                new CategoryViewModel() { Id = new Guid("6a691eb6-9bcb-4f77-bfaa-5b894a6d2843"), Name = "Y"},
                new CategoryViewModel() { Id = new Guid("4aa4d01c-808d-489d-94c9-da533a3bbeb6"), Name = "Z"},
            };

            return categoryList;
        }
    }
}
