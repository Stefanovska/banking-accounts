import { Amount } from "./amount";

export interface Transaction {
  amount: Amount | null;
}