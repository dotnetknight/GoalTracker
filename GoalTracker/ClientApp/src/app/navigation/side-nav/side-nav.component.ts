import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SidenavComponent implements OnInit, OnDestroy {
  isAuth = false;
  @Output() sidenavToggle = new EventEmitter<void>();

  constructor() { }


  ngOnInit() {

  }

  ngOnDestroy() {
  }

  close() {
    if (window.innerWidth < 500) {
      this.sidenavToggle.emit();
    }
  }

  onLogout() {

  }
}