import { NotificationError } from './NotificationError';
import { NotificationMessage } from './NotificationMessage';

export interface NotificationResult {
  isValid: boolean;
  errors: NotificationError[];
  messages: NotificationMessage[];
  data: any;
}
