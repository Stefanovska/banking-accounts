import { Amount } from "./amount";
import { Transaction } from "./transaction";

export interface UserAccount {
  id: string;
  initialCredit: Amount;
  isCurrent: boolean;
  customerId: string | null;
  transactions: Transaction[] | null;
}