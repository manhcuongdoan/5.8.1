import { Component, Injector, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { TaskServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateTaskDialogComponent } from './create-task-dialog/create-task-dialog.component';
import { EditTaskDialogComponent } from './edit-task-dialog/edit-task-dialog.component';
import {
  TaskDto,
} from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';

class PagedTaskRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css'],
  animations: [appModuleAnimation()]
})

export class TasksComponent extends PagedListingComponentBase<TaskDto> implements OnInit {

  tasks: TaskDto[];
  keyword = '';
  constructor(
    injector: Injector,
    private _modalService: BsModalService,
    private _taskService: TaskServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    // this.getTasks();
    this.getTaskSearch(this.keyword);
  }

  createTask(): void {
    this.showCreateOrEditTaskDialog();
  }
  editTask(id: number): void {
    this.showCreateOrEditTaskDialog(id);
  }

  showCreateOrEditTaskDialog(id?: number): void {
    let createOrEditTaskDialog: BsModalRef;
    if(!id) {
      createOrEditTaskDialog = this._modalService.show(
        CreateTaskDialogComponent, {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditTaskDialog = this._modalService.show(
        EditTaskDialogComponent, {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );

    }
    createOrEditTaskDialog.content.onSave.subscribe(() => {
      this.ngOnInit();
    });

  }


  protected list(request: PagedTaskRequestDto, pageNumber: number, finishedCallback: Function): void {
    // request.keyword = this.keyword;
    // this._taskService.getTaskAll(this.keyword);
  }
  protected delete(entity: TaskDto): void {

  }

  getTasks() {
    this._taskService.getTasks().subscribe(resp =>
      this.tasks = resp.result.tasks);
  }

  getTaskSearch(keyword?: string) {
    this._taskService.getTaskSearch(keyword).subscribe(resp =>
      this.tasks = resp.result.tasks);
  }

}
