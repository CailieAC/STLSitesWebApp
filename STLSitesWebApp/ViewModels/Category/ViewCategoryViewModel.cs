using STLSitesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels.Category
{
    public class ViewCategoryViewModel
    {
        public int Id { get; set; }
        public Models.Category Category { get; set; }
        public IList<CategoryLocation> Items { get; set; }

        public ViewCategoryViewModel()
        { }

        public ViewCategoryViewModel(Models.Category category, List<CategoryLocation> items)
        {
            this.Category = category;
            this.Items = items;
        }
    }
}
