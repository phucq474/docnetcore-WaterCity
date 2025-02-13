using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.KyGhiChiSo;
using WaterCity.Core.Models;
using WaterCity.Contract.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class KyGhiChiSoController : ControllerBase
    {
        private readonly IKyGhiChiSoService _iKyGhiChiSoService;

        public KyGhiChiSoController(IKyGhiChiSoService iKyGhiChiSoService)
        {
            _iKyGhiChiSoService = iKyGhiChiSoService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.KyGhiChiSo.GetAllKyGhiChiSo)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iKyGhiChiSoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KyGhiChiSoEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KyGhiChiSo.GetKyGhiChiSo)]
        public async Task<IActionResult> GetKyGhiChiSoById(string keyId)
        {
            var data = await _iKyGhiChiSoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKyGhiChiSo.KY_GHI_CHI_SO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KyGhiChiSoEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.KyGhiChiSo.GetAllKyGhiChiSo)]
        public IActionResult GetAll()
        {
            var result = _iKyGhiChiSoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KyGhiChiSoEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KyGhiChiSo.GetKyGhiChiSo)]
        public IActionResult GetKyGhiChiSoById(string keyId)
        {
            var data = _iKyGhiChiSoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKyGhiChiSo.KY_GHI_CHI_SO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KyGhiChiSoEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KyGhiChiSo.AddKyGhiChiSo)]
        public async Task<IActionResult> CreateKyGhiChiSo(KyGhiChiSoModel KyGhiChiSo)
        {
            try
            {
                var result = await _iKyGhiChiSoService.CreateAsync(KyGhiChiSo);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status201Created, code: ResponseCodeConstants.SUCCESS, data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.KyGhiChiSo.UpdateKyGhiChiSo)]
        public async Task<IActionResult> UpdateKyGhiChiSo(string keyId, KyGhiChiSoModel request)
        {
            try
            {
                await _iKyGhiChiSoService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsKyGhiChiSo.UPDATE_KY_GHI_CHI_SO_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        [Route(WebApiEndpoint.KyGhiChiSo.DeleteKyGhiChiSo)]
        public async Task<IActionResult> DeleteKyGhiChiSo(string keyId)
        {
            try
            {
                await _iKyGhiChiSoService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsKyGhiChiSo.DELETE_KY_GHI_CHI_SO_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
