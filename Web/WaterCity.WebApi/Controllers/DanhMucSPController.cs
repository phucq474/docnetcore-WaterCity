using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.DanhMucSP;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class DanhMucSPController : ControllerBase
    {
        private readonly IDanhMucSPService _iDanhMucSPService;

        public DanhMucSPController(IDanhMucSPService iDanhMucSPService)
        {
            _iDanhMucSPService = iDanhMucSPService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.DanhMucSP.GetAllDanhMucSP)]
        public IActionResult GetAll()
        {
            var result = _iDanhMucSPService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DanhMucSPEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DanhMucSP.GetDanhMucSP)]
        public IActionResult GetDanhMucSPById(string keyId)
        {
            var data = _iDanhMucSPService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsDanhMucSP.DANHMUCSP_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DanhMucSPEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DanhMucSP.AddDanhMucSP)]
        public async Task<IActionResult> CreateDanhMucSP(DanhMucSPModel model)
        {
            try
            {
                var result = await _iDanhMucSPService.CreateAsync(model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS,
                    data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.DanhMucSP.UpdateDanhMucSP)]
        public async Task<IActionResult> UpdateDanhMucSP(string keyId, DanhMucSPModel model)
        {
            try
            {
                await _iDanhMucSPService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDanhMucSP.UPDATE_DANHMUCSP_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        [Route(WebApiEndpoint.DanhMucSP.DeleteDanhMucSP)]
        public async Task<IActionResult> DeleteDanhMucSP(string keyId)
        {
            try
            {
                await _iDanhMucSPService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDanhMucSP.DELETE_DANHMUCSP_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
