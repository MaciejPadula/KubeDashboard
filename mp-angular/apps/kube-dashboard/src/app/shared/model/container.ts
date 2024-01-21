import { TaggedImage } from "./tagged-image";

export interface Container {
  ports: number[];
  image: TaggedImage;
}