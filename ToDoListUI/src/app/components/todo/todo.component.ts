import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ITask } from 'src/app/models/task';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import ValidateForm from 'src/app/helpers/validateForm';
import { TaskService } from 'src/app/services/task/task.service';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent {
  todoForm !: FormGroup;
  tasks : ITask [] = [];
  inprogress : ITask [] = [];
  done : ITask [] = []

  updateIndex!:any;
  isEditEnabled : boolean = false;

  constructor(private fb: FormBuilder, private service: TaskService){

  }

  ngOnInit(): void {
    
    let allTasks : ITask[] = [];
    
    this.service.getTasks(5).subscribe(
      response => {
        allTasks = response
        this.filterTasks(allTasks)
      }
    );

    this.todoForm = this.fb.group({
      title : ['', Validators.required],
      description : ['', Validators.required]
    })
  }

  addTask() {
    if(this.todoForm.valid){
      if(this.todoForm.value.title=='' || this.todoForm.value.description=='') {
        alert("Required task message")
      }else{

        var task = {
          id: 1000,
          description: this.todoForm.value.title,
          status: -1,
          title: this.todoForm.value.description,
          userId: 5
        }
        
        this.service.createTask(task).subscribe();
        this.tasks.push(task)
        this.todoForm.reset()
      }
    }else{
      ValidateForm.validateAllFormFields(this.todoForm)
    }
    
    
  }

  onEdit(task: ITask, i: number) {
    

    this.todoForm.controls['title'].setValue(task.title);
    this.todoForm.controls['description'].setValue(task.description)
    this.updateIndex = i;
    this.isEditEnabled = true;
  }

  updateTask() {
    var todo = this.tasks[this.updateIndex];
    var update = {
      description: this.todoForm.value.title,
      title: this.todoForm.value.description,
      status: todo.status
    };

    this.service.updateTask(update, todo.id).subscribe()

    this.tasks[this.updateIndex].description = this.todoForm.value.description
    this.tasks[this.updateIndex].title = this.todoForm.value.title
    this.todoForm.reset()
    this.updateIndex = undefined
    this.isEditEnabled = false
  }

  deleteTask(i: number) {
    let task = this.tasks[i];

    this.service.deleteTask(task.id).subscribe();

    this.tasks.splice(i, 1)
    this.isEditEnabled = false
    this.todoForm.reset()
  }

  deleteInprogress(i: number) {
    let task = this.inprogress[i];

    this.service.deleteTask(task.id).subscribe(
    );

    this.inprogress.splice(i, 1)
    this.isEditEnabled = false
    this.todoForm.reset()
  }

  deleteDoneTask(i: number) {
    let task = this.done[i];

    this.service.deleteTask(task.id).subscribe(
    );

    this.done.splice(i, 1)
    this.isEditEnabled = false
    this.todoForm.reset()
  }

  drop(event: CdkDragDrop<ITask[]>) {
    var temp = event.previousContainer.data[event.previousIndex];
    let id = temp.id
    var str = event.container.id


    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex,
      );
    }

    var stat: number = 0;
    if (str=="done"){
      stat = 1;
    }else if(str=="todo") {
      stat = -1;
    }

    var update = {
      description: temp.description,
      title: temp.title,
      status: stat
    }

    this.service.updateTask(update, id).subscribe()
    
  }
  
  filterTasks(allTask: ITask[]) {
    allTask.forEach(task => {
      if(task.status==1) {
        this.done.push(task)
      }else if(task.status==0) {
        this.inprogress.push(task)
      }else if(task.status==-1) {
        this.tasks.push(task)
      }
    })
  }

}
