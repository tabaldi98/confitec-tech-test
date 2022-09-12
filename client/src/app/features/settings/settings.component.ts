import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs/operators';
import { AuthService } from 'src/app/core/authentication/authentication.service';
import { LocalStorageKeys } from 'src/app/core/local-storage/local-storage.model';
import { LocalStorageService } from 'src/app/core/local-storage/local-storage.service';
import { SESSION_TIME_SETTING_ID, ISetting } from './shared/settings.model';
import { SettingsService } from './shared/settings.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
  form!: FormGroup;
  isLoading: boolean = true;

  // Permissions
  showGeneralSettings: boolean = false;

  constructor(
    private localStorageService: LocalStorageService,
    private settingsService: SettingsService,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.showGeneralSettings = this.authService.hasCanChangeGeneralSettingsRole;
    if (this.showGeneralSettings) {
      this.settingsService.getAll()
        .pipe(take(1))
        .subscribe((settings: ISetting[]) => {
          this.form = new FormGroup({
            sidebar: new FormControl(this.localStorageService.getBoolValue(LocalStorageKeys.SideNav), [Validators.required]),
            session: new FormControl(settings.find((s: ISetting) => s.id == SESSION_TIME_SETTING_ID)?.value, [Validators.required])
          })
          this.isLoading = false;
        })
    } else {
      this.form = new FormGroup({
        sidebar: new FormControl(this.localStorageService.getBoolValue(LocalStorageKeys.SideNav), [Validators.required]),
      })
      this.isLoading = false;
    }
  }

  onSaveSideBar(): void {
    const value: boolean = this.form.get('sidebar')?.value;
    this.localStorageService.setBoolValue(LocalStorageKeys.SideNav, value);
  }

  onSaveSession(): void {
    const value: number = this.form.get('session')?.value;
    this.saveChanges(SESSION_TIME_SETTING_ID, value.toString());
  }

  saveChanges(id: number, value: string): void {
    this.isLoading = true;
    this.settingsService.edit({
      id,
      value: value
    }).subscribe(() => {
      this.isLoading = false;
    })
  }
}
