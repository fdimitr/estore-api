using estore_common;
using estore_logic;
using estore_model;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;

namespace estore_api.Controllers
{
    [Authorize]
    [ODataRoutePrefix("category")]
    public class CategoryController : ODataController
    {
        CategoryLogic Logic = new CategoryLogic();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: odata/Category
        [ODataRoute]
        [HttpGet]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<Category> Get()
        {
            return Logic.GetAll();
        }

        // GET: odata/Category(1)
        [ODataRoute(ControllerConstants.RouteById)]
        [HttpGet]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<Category> GetById([FromODataUri] int id)
        {
            return await Logic.GetById(id);
        }

        // POST: odata/Category
        [HttpPost]
        public async Task<IHttpActionResult> Post(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category result = await Logic.Create(category);

            return Created(result);
        }

        // Patch: odata/Category(5)
        [HttpPatch]
        [ODataRoute(ControllerConstants.RouteById)]
        public async Task<IHttpActionResult> Patch([FromODataUri] int id, Delta<Category> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await Logic.Patch(id, patch);

            if (!result)
            {
                return NotFound();
            }

            return Updated(result);
        }

        // DELETE: odata/Categories(5)
        [HttpDelete]
        [ODataRoute(ControllerConstants.RouteById)]
        public async Task<IHttpActionResult> Delete([FromODataUri] int id)
        {
            bool result = await Logic.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


    }
}
