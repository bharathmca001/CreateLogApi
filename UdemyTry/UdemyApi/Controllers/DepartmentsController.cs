using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyApi.Contract;
using UdemyApi.Data;
using UdemyApi.Model.Department;

namespace UdemyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
       // private readonly UniversityDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        // in cons i removed the db context
        public DepartmentsController(IMapper mapper,IDepartmentRepository departmentRepository)
        {
          //  _context = context;
            this._mapper = mapper;
            this._departmentRepository = departmentRepository;
        }





        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDepartmentDto>>> GetDepartments()
        {
          //  var departments = await _context.Departments.ToListAsync();


            var departments = await _departmentRepository.GetAllAsync();
            var records = _mapper.Map<List<GetDepartmentDto>>(departments);
            return Ok(records);
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
           // var department = await _context.Departments.Include(q => q.Courses).FirstOrDefaultAsync(q => q.Id == id);

            // here we can't use the generic method because here we use include another table 
           // so here we use the specific repository.

            var department = await _departmentRepository.GetDetails(id);
           

            if (department == null)
            {
                return NotFound();
            }
            var records = _mapper.Map<DepartmentDto>(department);

            return Ok(records);
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, UpdateDepartmentDto updateDepartmentDto)
        {
            if (id != updateDepartmentDto.Id)
            {
                return BadRequest();
            }

           // _context.Entry(department).State = EntityState.Modified;

         //   var country = await _context.Departments.FindAsync(id);
            var country = await _departmentRepository.GetAsync(id);
            if (country == null) { return BadRequest(); }
            // i dont know below one line right or wrong
            // _mapper.Map<UpdateDepartmentDto>(country);
            _mapper.Map(updateDepartmentDto, country); 

            try
            {
              //  await _context.SaveChangesAsync();
              await _departmentRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DepartmentExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(CreateDepartmentDto createDepartment)
        {
            var department = _mapper.Map<Department>(createDepartment);
        //    _context.Departments.Add(department);
        //    await _context.SaveChangesAsync();
            await _departmentRepository.AddAsync(department);

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
         //   var department = await _context.Departments.FindAsync(id);
            var department = await _departmentRepository.GetAsync(id);

            if (department == null)
            {
                return NotFound();
            }

           // _context.Departments.Remove(department);
          //  await _context.SaveChangesAsync();
          await _departmentRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> DepartmentExists(int id)
        {
            //return _context.Departments.Any(e => e.Id == id);
            return await _departmentRepository.Exites(id);
        }
    }
}
