using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StocksApp.Services;
using StocksApp.Model.StockModel;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksApp.Controllers
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : Controller
    {
        private IStockService _service;

        public StocksController(IStockService service)
        {
            _service = service;
        }

        // GET: get all available stocks
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _service.GETALL(null);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET get information of one single stock
        [HttpGet("{id}")]
        public IActionResult Get([FromBody]StockRequest request)
        {
            return Ok(new Response() { Success = true, Message = "NotImplemented" });
        }

        //Post : Buy Stock
        [HttpPost("buy")]
        public async Task<IActionResult> BuyStock([FromBody]StockRequest request)
        {
            try
            {
                var accessToken = Request.Headers["Authorization"];
                var response = await _service.BUY(request, accessToken);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        //Post : Sell Stock
        [HttpPost("sell")]
        public async Task<IActionResult> SellStock([FromBody]StockRequest request)
        {
            try
            {
                var accessToken = Request.Headers["Authorization"];
                var response = await _service.SELL(request, accessToken);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
