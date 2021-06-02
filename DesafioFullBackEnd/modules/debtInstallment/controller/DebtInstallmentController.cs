using DesafioFULL.modules.debtInstallment.model;
using DesafioFULL.modules.debtInstallment.service;
using DesafioFULL.tools.annotations;
using DesafioFULL.tools.mongoConnection;
using System.Threading.Tasks;
using System.Web.Http;

namespace DesafioFULL.modules.debtInstallment.controller
{
    [FullRoutePrefix("debtInstallment")]
    public class DebtInstallmentController : MongoGenericController<DebtInstallment>
    {
        private IDebtInstallmentService _service;
        public DebtInstallmentController(IDebtInstallmentService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("table/{id}")]
        public async Task<IHttpActionResult> GetTable([FromUri] string id)
        {
            return Ok(await _service.GetTable(id));
        }
    }
}