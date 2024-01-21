import { Container } from "../../../shared/model/container";

export interface CreateDeploymentRequest {
  name: string;
  replicas: number;
  namespace: string;
  containers: Container[];
}