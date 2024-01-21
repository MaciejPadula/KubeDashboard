import { Container } from "./container";

export interface Deployment {
  name: string;
  replicas: number;
  aliveReplicas: number;
  namespace: string;
  containers: Container[];
}