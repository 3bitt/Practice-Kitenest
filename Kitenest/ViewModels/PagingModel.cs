using Kitenest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitenest.ViewModels
{
    public class PaginationModel : PageModel
    {
        private readonly IPersonService _schoolService;

        public PaginationModel(IPersonService personService)
        {
            _schoolService = personService;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<Models.School> Data { get; set; }

        public async Task OnGetAsync()
        {
            Data = await _schoolService.GetPaginatedResult(CurrentPage, PageSize);
            Count = await _schoolService.GetCount();
        }
    }

    public interface IPersonService
    {
        Task<List<School>> GetPaginatedResult(int currentPage, int pageSize = 10);
        Task<int> GetCount();
    }
}

    //public class PersonService : IPersonService
    //{
    //    //private readonly _context _hostingEnvironment;
        //public PersonService(IHostingEnvironment hostingEnvironment)
        //{
        //    _hostingEnvironment = hostingEnvironment;
        //}

        //public async Task<List<School>> GetPaginatedResult(int currentPage, int pageSize = 10)
        //{
        //    var data = await GetData();
        //    return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        //}

        //public async Task<int> GetCount()
        //{
        //    var data = await GetData();
        //    return data.Count;
        //}

        //private async Task<List<School>> GetData()
        //{
        //    var json = await File.ReadAllTextAsync(Path.Combine(_hostingEnvironment.ContentRootPath, "Data", "paging.json"));
        //    return JsonConvert.DeserializeObject<List<Person>>(json);
//        //}
//    }
//}
