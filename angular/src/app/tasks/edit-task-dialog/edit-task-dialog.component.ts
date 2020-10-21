import { Component, EventEmitter, Injector, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AppComponentBase } from '@shared/app-component-base';
import { EditTaskDto, TaskServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
@Component({
  selector: 'app-edit-task-dialog',
  templateUrl: './edit-task-dialog.component.html',
  styleUrls: ['./edit-task-dialog.component.css']
})
export class EditTaskDialogComponent extends AppComponentBase implements OnInit {

  @Input() id;
  @Output() onSave = new EventEmitter<any>();
  constructor(
    injector: Injector,
    private _taskService : TaskServiceProxy,
    public bsModalRef: BsModalRef) {
      super(injector);
    }

  ngOnInit(): void {
    // this._taskService
    //   .getTaskForEdit(this.id)
    //   .subscribe((result: GetRoleForEditOutput) => {
    //     this.role = result.role;
    //     this.permissions = result.permissions;
    //     this.grantedPermissionNames = result.grantedPermissionNames;
    //     this.setInitialPermissionsStatus();
    //   });
  }

  save(f: NgForm) {
    const task = new EditTaskDto();
    task.state = f.value.state;
    task.assignedPersonId = f.value.assignedPersonId;
    task.taskId = this.id;

    this._taskService.updateTask(task).subscribe(() => {
      resp => console.log(resp);
      this.bsModalRef.hide();
      this.onSave.emit();
    })

  }


}
