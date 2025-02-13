using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.NhaCungCap;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private readonly INhaCungCapService _iNhaCungCapService;

        public NhaCungCapController(INhaCungCapService iNhaCungCapService)
        {
            _iNhaCungCapService = iNhaCungCapService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.NhaCungCap.GetAllNhaCungCap)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iNhaCungCapService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhaCungCapEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhaCungCap.GetNhaCungCap)]
        public async Task<IActionResult> GetNhaCungCapById(string keyId)
        {
            var data = await _iNhaCungCapService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<NhaCungCapEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.NhaCungCap.GetAllNhaCungCap)]
        public IActionResult GetAll()
        {
            var result = _iNhaCungCapService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhaCungCapEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhaCungCap.GetNhaCungCap)]
        public IActionResult GetNhaCungCapById(string keyId)
        {
            var data = _iNhaCungCapService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<NhaCungCapEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NhaCungCap.AddNhaCungCap)]
        public async Task<IActionResult> CreateNhaCungCap(NhaCungCapModel model)
        {
            try
            {
                var result = await _iNhaCungCapService.CreateAsync(model);
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
        [Route(WebApiEndpoint.NhaCungCap.UpdateNhaCungCap)]
        public async Task<IActionResult> UpdateNhaCungCap(string keyId, NhaCungCapModel model)
        {
            try
            {
                await _iNhaCungCapService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNhaCungCap.UPDATE_NHACUNGCAP_SUCCESS));
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
        [Route(WebApiEndpoint.NhaCungCap.DeleteNhaCungCap)]
        public async Task<IActionResult> DeleteNhaCungCap(string keyId)
        {
            try
            {
                await _iNhaCungCapService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNhaCungCap.DELETE_NHACUNGCAP_SUCCESS));
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
