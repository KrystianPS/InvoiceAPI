using AutoMapper;
using InvoiceAPI.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{

    [Route("/category")]
    public class ProductCategoryController : ControllerBase
    {

        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProductCategoryController(InvoiceAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

    }
}
