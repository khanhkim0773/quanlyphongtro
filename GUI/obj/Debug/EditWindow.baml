   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	       GUI.EditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   localclr-namespace:GUI  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5	   	     MaterialDesignPaper#���  5
   	     MaterialDesignFont#���  5   	    � Title$ 	Edit Room��5   	   $
��auto��5   	   $
��1000��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   � $��0��6   $	��150��5      .+�5      #  MaterialDesignThemes.Wpf.Card  $
��auto��6"   $��0q�6/   ���#03a9f4 ! PrimaryHueDarkForegroundBrush#���  5   "   .��5      � $
��auto��6    � ColumnDefinitions 5      �� 5      6-   �� 5      6-   .+�5!      � $��0��6   .+�5"      �� -   5         ��Name$ txbRoomNumber��5"   $   $��0��6;   $��60(�6K   $��Center=�5#   $   $��Center=�6A    $  MaterialDesignHeadline5TextBlock#��[ 5$   $   5%      � 5&      $��1��6   .+�5'      �  � Orientation$ Vertical=�6$   $��Center=�5(   $   .+�5)      �� -   5        $ txbRoomRate��5)   (   $��0��6=   $��25(�6M   $
��Left=�5*   (   $��Center=�6C   #��[ 5+   (   �� 5-      -   5        $ txbElectricityBill��5-   (   $��0��6E   $��25(�6V   $
��Left=�5.   (   $��Center=�6C   #��[ 5/   (   �� 51      -   5        $ txbWaterBill��51   (   $��0��6>   $��25(�6N   $
��Left=�52   (   $��Center=�6C   #��[ 53   (   54      55      56      59      5:      � 5<   
   $��1��6   $��Center=�6    5=      �� 5>      $	��850 �6#   61   �� 5?      $	��120 �6#   61   .+�5A      � $��0��6   $
��Left=�6#   .+�5B      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dtgTenant��5B      	   CanUserAddRows	 .  
   SelectionMode$
 Extended=�5C         SelectionUnit$
 Cell=�64      AutoGenerateColumns .  ��5B   F   �� *
ListTenant+   Columns 5E      4  .System.Windows.Controls.DataGridCheckBoxColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 61   0  *System.Windows.Controls.DataGridTextColumn  5G         Header$
 Tên��6-   $	 150 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Name+6S     5H      $ 
Ngày sinh��6-   $	 150 6`    6@   �� *DateOfBirth+6`     5I      $ Giới tính��6-   $	 100 6[    6@   �� *Gender+6[     5J      $	 SDT��6-   $	 150 6Z    6:   �� *PhoneNumber+6Z     5K      $ Email��6-   $	 150 6V    6<   �� *Email+6V     5L      $
 CCCD��6-   $	 150 6U    6;   �� *CCCD+6U   5N      5O      � 5Q      $��1��6   $��Right=�6#   .+�5R      � $ Vertical=�6   $��Center=�63   .+�5T      �� -   5         ��Name$ btnAddTenant��5T      +	  %MaterialDesignThemes.Wpf.ButtonAssist 	  CornerRadius$ 10��5U      $��50��6L   $	��100��5V      $��4q�6*   .��5W      �� $��Thêm��6$   5X      �� 5Z      -   5        $ btnEditTenant��5Z      $ 10��5[      $��50��5\      $	��100��6)   $��4q�66   .��5]      �� $��Sửa��6$   5^      �� 5`      -   5        $ btnDeleteTenant��5`      $ 10��5a      $��50��6K   $	��100��6W   $��4q�6c   .��5b      �� $
��Xóa��6$   5c      5d      5e      5f      � 5h   
   $��2��6   $
��auto��5i      .+�5j      �� -	   5        $ btnUpdateRoom��5j      $��50��5l      $	��100��6!   $��16(�6-   $��12q�6;   $ 5��5m      .��5n      �� $��Cập nhật��6   5o      5p      5q      5r      