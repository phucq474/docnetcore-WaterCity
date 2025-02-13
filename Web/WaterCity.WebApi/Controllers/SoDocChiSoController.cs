using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.SoDocChiSo;
using WaterCity.Core.Models;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class SoDocChiSoController : ControllerBase
    {
        private readonly ISoDocChiSoService _iSoDocChiSoService;

        public SoDocChiSoController(ISoDocChiSoService iSoDocChiSoService)
        {
            _iSoDocChiSoService = iSoDocChiSoService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.SoDocChiSo.GetAllSoDocChiSo)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iSoDocChiSoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<SoDocChiSoEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.SoDocChiSo.GetSoDocChiSo)]
        public async Task<IActionResult> GetSoDocChiSoById(string keyId)
        {
            var data = await _iSoDocChiSoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSoDocChiSo.SO_DOC_CHI_SO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<SoDocChiSoEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.SoDocChiSo.GetAllSoDocChiSo)]
        public IActionResult GetAll()
        {
            var result = _iSoDocChiSoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<SoDocChiSoEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.SoDocChiSo.GetSoDocChiSo)]
        public IActionResult GetSoDocChiSoById(string keyId)
        {
            var data = _iSoDocChiSoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSoDocChiSo.SO_DOC_CHI_SO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<SoDocChiSoEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.SoDocChiSo.AddSoDocChiSo)]
        public async Task<IActionResult> CreateSoDocChiSo(SoDocChiSoModel SoDocChiSo)
        {
            try
            {
                var result = await _iSoDocChiSoService.CreateAsync(SoDocChiSo);
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
        [Route(WebApiEndpoint.SoDocChiSo.UpdateSoDocChiSo)]
        public async Task<IActionResult> UpdateSoDocChiSo(string keyId, SoDocChiSoModel request)
        {
            try
            {
                await _iSoDocChiSoService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsSoDocChiSo.UPDATE_SO_DOC_CHI_SO_SUCCESS));
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
        [Route(WebApiEndpoint.SoDocChiSo.DeleteSoDocChiSo)]
        public async Task<IActionResult> DeleteSoDocChiSo(string keyId)
        {
            try
            {
                await _iSoDocChiSoService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsSoDocChiSo.DELETE_SO_DOC_CHI_SO_SUCCESS));
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
