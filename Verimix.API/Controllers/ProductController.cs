namespace Verimix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILogger<ProductController> logger;
        private readonly VerimixDbContext dbContext;

        public ProductController(ILogger<ProductController> logger, VerimixDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
    }
}