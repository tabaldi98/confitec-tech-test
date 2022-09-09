import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { MatSnackBar } from '@angular/material/snack-bar';
import { take } from 'rxjs/operators';
import { LocalStorageKeys } from 'src/app/core/local-storage/local-storage.model';
import { LocalStorageService } from 'src/app/core/local-storage/local-storage.service';
import { SESSION_TIME_SETTING_ID, ISetting, SIDE_BAR_SETTING_ID } from './shared/settings.model';
import { SettingsService } from './shared/settings.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
  form!: FormGroup;
  isLoading: boolean = true;

  constructor(
    private localStorageService: LocalStorageService,
    private snackBar: MatSnackBar,
    private settingsService: SettingsService) { }

  ngOnInit(): void {
    this.settingsService.getAll()
      .pipe(take(1))
      .subscribe((settings: ISetting[]) => {
        const sideBarValue: any = settings.find((s: ISetting) => s.id == SIDE_BAR_SETTING_ID)?.value;
        this.form = new FormGroup({
          sidebar: new FormControl(sideBarValue === '1' ? true : false, [Validators.required]),
          session: new FormControl(settings.find((s: ISetting) => s.id == SESSION_TIME_SETTING_ID)?.value, [Validators.required])
        })
        this.isLoading = false;

        this.localStorageService.setBoolValue(LocalStorageKeys.SideNav, sideBarValue === '1');
      })
  }

  onToggleChange(toggle: MatSlideToggleChange): void {
    this.isLoading = true;
    this.settingsService.edit({
      id: SIDE_BAR_SETTING_ID,
      value: toggle.checked ? '1' : '0'
    }).subscribe(() => {
      this.localStorageService.setBoolValue(LocalStorageKeys.SideNav, toggle.checked);
      this.isLoading = false;
    })
  }
}