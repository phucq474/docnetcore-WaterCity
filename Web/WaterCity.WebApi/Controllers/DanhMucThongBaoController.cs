using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.DanhMucThongBao;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class DanhMucThongBaoController : ControllerBase
    {
        private readonly IDanhMucThongBaoService _iDanhMucThongBaoService;

        public DanhMucThongBaoController(IDanhMucThongBaoService iDanhMucThongBaoService)
        {
            _iDanhMucThongBaoService = iDanhMucThongBaoService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.DanhMucThongBao.GetAllDanhMucThongBao)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iDanhMucThongBaoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DanhMucThongBaoEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DanhMucThongBao.GetDanhMucThongBao)]
        public async Task<IActionResult> GetDanhMucThongBaoById(string keyId)
        {
            var data = await _iDanhMucThongBaoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest, 
                    code: ResponseCodeConstants.NOT_FOUND, 
                    message: ReponseMessageConstantsDanhMucThongBao.DANH_MUC_THONG_BAO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DanhMucThongBaoEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.DanhMucThongBao.GetAllDanhMucThongBao)]
        public IActionResult GetAll()
        {
            var result = _iDanhMucThongBaoService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DanhMucThongBaoEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DanhMucThongBao.GetDanhMucThongBao)]
        public IActionResult GetDanhMucThongBaoById(string keyId)
        {
            var data = _iDanhMucThongBaoService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsDanhMucThongBao.DANH_MUC_THONG_BAO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DanhMucThongBaoEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DanhMucThongBao.AddDanhMucThongBao)]
        public async Task<IActionResult> CreateDanhMucThongBao(DanhMucThongBaoModel model)
        {
            try
            {
                var result = await _iDanhMucThongBaoService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DanhMucThongBao.UpdateDanhMucThongBao)]
        public async Task<IActionResult> UpdateDanhMucThongBao(string keyId, DanhMucThongBaoModel model)
        {
            try
            {
                await _iDanhMucThongBaoService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDanhMucThongBao.UPDATE_DANH_MUC_THONG_BAO_SUCCESS));
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
        [Route(WebApiEndpoint.DanhMucThongBao.DeleteDanhMucThongBao)]
        public async Task<IActionResult> DeleteDanhMucThongBao(string keyId)
        {
            try
            {
                await _iDanhMucThongBaoService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDanhMucThongBao.DELETE_DANH_MUC_THONG_BAO_SUCCESS));
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
