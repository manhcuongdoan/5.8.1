import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateTaskDto, TaskDto, TaskServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-create-task-dialog',
  templateUrl: './create-task-dialog.component.html',
  styleUrls: ['./create-task-dialog.component.css']
})
export class CreateTaskDialogComponent extends AppComponentBase implements OnInit {
  task = new TaskDto();
  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _taskService : TaskServiceProxy,
    public bsModalRef: BsModalRef) {
      super(injector);
    }

  ngOnInit(): void {




  }

  save(f: NgForm) {
    const task = new CreateTaskDto();
    task.init(f.value);
    this._taskService.create(task).subscribe(() => {
      resp => console.log(resp);
      this.bsModalRef.hide();
      this.onSave.emit();
    })
  }
}
