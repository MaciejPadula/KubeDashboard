import { TaggedImage } from "./tagged-image";

export interface Deployment {
  name: string;
  replicas: number;
  aliveReplicas: number;
  namespace: string;
  images: TaggedImage[];
}