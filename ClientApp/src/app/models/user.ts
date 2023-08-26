import { Amount } from "./amount";
import { UserAccount } from "./userAccount";

export interface User {
  id: string;
  name: string;
  surname: string;
  balance: Amount | null;
  userAccounts: UserAccount[] | null;
}