using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.PhienInThongBao;
using WaterCity.Core.Models;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class PhienInThongBaoController : ControllerBase
    {
        private readonly IPhienInThongBaoService _iPhienInThongBaoService;

        public PhienInThongBaoController(IPhienInThongBaoService iPhienInThongBaoService)
        {
            _iPhienInThongBaoService = iPhienInThongBaoService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.PhienInThongBao.GetAllPhienInThongBao)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iPhienInThongBaoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<PhienInThongBaoEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhienInThongBao.GetPhienInThongBao)]
        public async Task<IActionResult> GetPhienInThongBaoById(string keyId)
        {
            var data = await _iPhienInThongBaoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<PhienInThongBaoEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.PhienInThongBao.GetAllPhienInThongBao)]
        public IActionResult GetAll()
        {
            var result = _iPhienInThongBaoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<PhienInThongBaoEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhienInThongBao.GetPhienInThongBao)]
        public IActionResult GetPhienInThongBaoById(string keyId)
        {
            var data = _iPhienInThongBaoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<PhienInThongBaoEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.PhienInThongBao.AddPhienInThongBao)]
        public async Task<IActionResult> CreatePhienInThongBao(PhienInThongBaoModel model)
        {
            try
            {
                var result = await _iPhienInThongBaoService.CreateAsync(model);
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
        [Route(WebApiEndpoint.PhienInThongBao.UpdatePhienInThongBao)]
        public async Task<IActionResult> UpdatePhienInThongBao(string keyId, PhienInThongBaoModel model)
        {
            try
            {
                await _iPhienInThongBaoService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsPhienInThongBao.UPDATE_PHIEN_IN_THONG_BAO_SUCCESS));
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
        [Route(WebApiEndpoint.PhienInThongBao.DeletePhienInThongBao)]
        public async Task<IActionResult> DeletePhienInThongBao(string keyId)
        {
            try
            {
                await _iPhienInThongBaoService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsPhienInThongBao.DELETE_PHIEN_IN_THONG_BAO_SUCCESS));
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
