namespace VMix.Net.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILogger<ProductController> logger;
        private readonly VMixDbContext dbContext;

        public ProductController(ILogger<ProductController> logger, VMixDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
    }
}