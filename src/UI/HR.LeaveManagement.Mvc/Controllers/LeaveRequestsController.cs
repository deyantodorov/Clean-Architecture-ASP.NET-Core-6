using System;
using System.Data;
using System.Threading.Tasks;

using HR.LeaveManagement.Mvc.Contracts;
using HR.LeaveManagement.Mvc.Models.LeaveRequest;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR.LeaveManagement.Mvc.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestsController(ILeaveTypeService leaveTypeService, ILeaveRequestService leaveRequestService)
        {
            _leaveTypeService = leaveTypeService;
            _leaveRequestService = leaveRequestService;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            var model = await _leaveRequestService.GetAdminLeaveRequestList();
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var model = await _leaveRequestService.GetLeaveRequest(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> ApproveRequest(int id, bool approved)
        {
            try
            {
                await _leaveRequestService.ApproveLeaveRequest(id, approved);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var leaveTypeItems = await LeaveTypeItems();
            var model = new CreateLeaveRequestVm { LeaveTypes = leaveTypeItems, };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveRequestVm model)
        {
            if (ModelState.IsValid)
            {
                var response =  await _leaveRequestService.CreateLeaveRequest(model);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }

            model.LeaveTypes = await LeaveTypeItems(); ;

            return View(model);

        }

        private async Task<SelectList> LeaveTypeItems()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();
            var leaveTypeItems = new SelectList(leaveTypes, "Id", "Name");

            return leaveTypeItems;
        }
    }
}
