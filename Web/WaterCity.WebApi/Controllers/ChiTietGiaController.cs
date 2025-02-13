using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.ChiTietGia;
using WaterCity.Core.Models;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class ChiTietGiaController : ControllerBase
    {
        private readonly IChiTietGiaService _iChiTietGiaService;

        public ChiTietGiaController(IChiTietGiaService iChiTietGiaService)
        {
            _iChiTietGiaService = iChiTietGiaService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.ChiTietGia.GetAllChiTietGia)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iChiTietGiaService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietGiaEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietGia.GetChiTietGia)]
        public async Task<IActionResult> GetChiTietGiaById(string keyId)
        {
            var data = await _iChiTietGiaService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietGia.CHI_TIET_GIA_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietGiaEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietGia.GetAllChiTietGia)]
        public IActionResult GetAll()
        {
            var result = _iChiTietGiaService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChiTietGiaEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChiTietGia.GetChiTietGia)]
        public IActionResult GetChiTietGiaById(string keyId)
        {
            var data = _iChiTietGiaService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietGia.CHI_TIET_GIA_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChiTietGiaEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChiTietGia.AddChiTietGia)]
        public async Task<IActionResult> CreateChiTietGia(ChiTietGiaModel ChiTietGia)
        {
            try
            {
                var result = await _iChiTietGiaService.CreateAsync(ChiTietGia);
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
        [Route(WebApiEndpoint.ChiTietGia.UpdateChiTietGia)]
        public async Task<IActionResult> UpdateChiTietGia(string keyId, ChiTietGiaModel request)
        {
            try
            {
                await _iChiTietGiaService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsChiTietGia.UPDATE_CHI_TIET_GIA_SUCCESS));
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
        [Route(WebApiEndpoint.ChiTietGia.DeleteChiTietGia)]
        public async Task<IActionResult> DeleteChiTietGia(string keyId)
        {
            try
            {
                await _iChiTietGiaService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsChiTietGia.DELETE_CHI_TIET_GIA_SUCCESS));
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
