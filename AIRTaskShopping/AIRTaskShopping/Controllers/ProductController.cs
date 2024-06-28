using AIRTaskShopping.Data;
using AIRTaskShopping.Models;
using AIRTaskShopping.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AIRTaskShopping.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly DataContext _dataContext;

    public ProductController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _dataContext.Products.Add(product);
        await _dataContext.SaveChangesAsync();
        return Ok(await _dataContext.Products.ToListAsync());

    }
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await _dataContext.Products.ToListAsync());

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> ReadId(int id)
    {
        if (id == null) return BadRequest(ModelState);
        var product = await _dataContext.Products.FindAsync(id);
        if (product == null) return BadRequest(ModelState);
        return Ok(product);
    }
    [HttpPut]
    public async Task<IActionResult> Update(Product product)
    {
        ProductValidator validations = new ProductValidator();
        var validationResult = validations.Validate(product);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
        _dataContext.Products.Update(product);
        await _dataContext.SaveChangesAsync();
        return Ok();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null) return BadRequest(ModelState);
        var product = await _dataContext.Products.FindAsync(id);
        if (product == null) return BadRequest(ModelState);
        _dataContext.Products.Remove(product);
        await _dataContext.SaveChangesAsync();
        return Ok();
    }
}
