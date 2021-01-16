using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StocksApp.Model.InvestmentModel;

namespace StocksApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentPortfoliosController : ControllerBase
    {
        private readonly InvestmentPortfolioContext _context;

        public InvestmentPortfoliosController(InvestmentPortfolioContext context)
        {
            _context = context;
        }

        // GET: api/InvestmentPortfolios
        [HttpGet]
        public IEnumerable<InvestmentPortfolio> GetInvestmentPortfolios()
        {
            return _context.InvestmentPortfolios;
        }

        // GET: api/InvestmentPortfolios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvestmentPortfolio([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var investmentPortfolio = await _context.InvestmentPortfolios.FindAsync(id);

            if (investmentPortfolio == null)
            {
                return NotFound();
            }

            return Ok(investmentPortfolio);
        }

        // PUT: api/InvestmentPortfolios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestmentPortfolio([FromRoute] long id, [FromBody] InvestmentPortfolio investmentPortfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investmentPortfolio.Id)
            {
                return BadRequest();
            }

            _context.Entry(investmentPortfolio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestmentPortfolioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InvestmentPortfolios
        [HttpPost]
        public async Task<IActionResult> PostInvestmentPortfolio([FromBody] InvestmentPortfolio investmentPortfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InvestmentPortfolios.Add(investmentPortfolio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestmentPortfolio", new { id = investmentPortfolio.Id }, investmentPortfolio);
        }

        // DELETE: api/InvestmentPortfolios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestmentPortfolio([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var investmentPortfolio = await _context.InvestmentPortfolios.FindAsync(id);
            if (investmentPortfolio == null)
            {
                return NotFound();
            }

            _context.InvestmentPortfolios.Remove(investmentPortfolio);
            await _context.SaveChangesAsync();

            return Ok(investmentPortfolio);
        }

        private bool InvestmentPortfolioExists(long id)
        {
            return _context.InvestmentPortfolios.Any(e => e.Id == id);
        }
    }
}