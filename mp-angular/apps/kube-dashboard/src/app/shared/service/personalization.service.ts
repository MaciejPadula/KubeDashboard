import { Injectable, signal } from '@angular/core';
import { Registry } from '../model/registry';

@Injectable({
  providedIn: 'root'
})
export class PersonalizationService {
  private readonly registryKey = 'currentRegistry';
  private readonly namespaceKey = 'currentNamespace';

  #currentNamespace = signal<string>('default');
  public currentNamespace = this.#currentNamespace.asReadonly();

  public init() {
    this.#currentNamespace.set(localStorage.getItem(this.namespaceKey) ?? 'default');
  }

  public setCurrentNamespace(namespace: string) {
    localStorage.setItem(this.namespaceKey, namespace);
    this.#currentNamespace.set(localStorage.getItem(this.namespaceKey) ?? 'default');
  }

  public get currentRegistry(): Registry {
    return JSON.parse(localStorage.getItem(this.registryKey) ?? '{}');
  }

  public set currentRegistry(registry: Registry) {
    localStorage.setItem(this.registryKey, JSON.stringify(registry));
  }
}
