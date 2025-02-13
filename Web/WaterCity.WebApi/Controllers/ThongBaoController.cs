using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.ThongBao;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        private readonly IThongBaoService _iThongBaoService;

        public ThongBaoController(IThongBaoService iThongBaoService)
        {
            _iThongBaoService = iThongBaoService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.ThongBao.GetAllThongBao)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iThongBaoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ThongBaoEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ThongBao.GetThongBao)]
        public async Task<IActionResult> GetThongBaoById(string keyId)
        {
            var data = await _iThongBaoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest, 
                    code: ResponseCodeConstants.NOT_FOUND, 
                    message: ReponseMessageConstantsThongBao.THONG_BAO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ThongBaoEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.ThongBao.GetAllThongBao)]
        public IActionResult GetAll()
        {
            var result = _iThongBaoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ThongBaoEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ThongBao.GetThongBao)]
        public IActionResult GetThongBaoById(string keyId)
        {
            var data = _iThongBaoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsThongBao.THONG_BAO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ThongBaoEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ThongBao.AddThongBao)]
        public async Task<IActionResult> CreateThongBao(ThongBaoModel model)
        {
            try
            {
                var result = await _iThongBaoService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ThongBao.UpdateThongBao)]
        public async Task<IActionResult> UpdateThongBao(string keyId, ThongBaoModel model)
        {
            try
            {
                await _iThongBaoService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsThongBao.UPDATE_THONG_BAO_SUCCESS));
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
        [Route(WebApiEndpoint.ThongBao.DeleteThongBao)]
        public async Task<IActionResult> DeleteThongBao(string keyId)
        {
            try
            {
                await _iThongBaoService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsThongBao.DELETE_THONG_BAO_SUCCESS));
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
