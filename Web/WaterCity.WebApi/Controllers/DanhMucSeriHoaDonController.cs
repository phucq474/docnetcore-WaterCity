using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.DanhMucSeriHoaDon;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class DanhMucSeriHoaDonController : ControllerBase
    {
        private readonly IDanhMucSeriHoaDonService _iDanhMucSeriHoaDonService;

        public DanhMucSeriHoaDonController(IDanhMucSeriHoaDonService iDanhMucSeriHoaDonService)
        {
            _iDanhMucSeriHoaDonService = iDanhMucSeriHoaDonService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.DanhMucSeriHoaDon.GetAllDanhMucSeriHoaDon)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iDanhMucSeriHoaDonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DanhMucSeriHoaDonEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DanhMucSeriHoaDon.GetDanhMucSeriHoaDon)]
        public async Task<IActionResult> GetDanhMucSeriHoaDonById(string keyId)
        {
            var data = await _iDanhMucSeriHoaDonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<DanhMucSeriHoaDonEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.DanhMucSeriHoaDon.GetAllDanhMucSeriHoaDon)]
        public IActionResult GetAll()
        {
            var result = _iDanhMucSeriHoaDonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DanhMucSeriHoaDonEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DanhMucSeriHoaDon.GetDanhMucSeriHoaDon)]
        public IActionResult GetDanhMucSeriHoaDonById(string keyId)
        {
            var data = _iDanhMucSeriHoaDonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<DanhMucSeriHoaDonEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DanhMucSeriHoaDon.AddDanhMucSeriHoaDon)]
        public async Task<IActionResult> CreateDanhMucSeriHoaDon(DanhMucSeriHoaDonModel model)
        {
            try
            {
                var result = await _iDanhMucSeriHoaDonService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DanhMucSeriHoaDon.UpdateDanhMucSeriHoaDon)]
        public async Task<IActionResult> UpdateDanhMucSeriHoaDon(string keyId, DanhMucSeriHoaDonModel model)
        {
            try
            {
                await _iDanhMucSeriHoaDonService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDanhMucSeriHoaDon.UPDATE_DANH_MUC_SERI_HOA_DON_SUCCESS));
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
        [Route(WebApiEndpoint.DanhMucSeriHoaDon.DeleteDanhMucSeriHoaDon)]
        public async Task<IActionResult> DeleteDanhMucSeriHoaDon(string keyId)
        {
            try
            {
                await _iDanhMucSeriHoaDonService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDanhMucSeriHoaDon.DELETE_DANH_MUC_SERI_HOA_DON_SUCCESS));
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
