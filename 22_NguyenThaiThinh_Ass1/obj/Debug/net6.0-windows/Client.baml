   M S B A M L   `   `   `  ����R  N22_NguyenThaiThinh_Ass1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:_22_NguyenThaiThinh_Ass1_22_NguyenThaiThinh_Ass1  5   	   %    _22_NguyenThaiThinh_Ass1.Client   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:_22_NguyenThaiThinh_Ass1     5   	     � Title$  22_NguyenThaiThinh_Ass1��5   	   $	��470��5	   	   $
��1100��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��0* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5      $��	305,0,0,0q�5      $
��Auto��5      .+�5      �� -   5        $��lvOrders��5      $��2��5      $
��Auto��5      $
��Auto��5      $
��Left=�5       �� View 5      �� 5      .P�5      �� $��OrderId��6)    �� Width$ 50��5   )    �� DisplayMemberBinding 5    )   ��  �� Path$ OrderId��� 5!      $��MemberId��6)   $ 60��5"   )    5#   )   �� $ MemberId��� 5$      $��
Order Date��6)   $	 120��5%   )    5&   )   �� $ 	OrderDate��� 5'      $��Required Date��6)   $	 120��5(   )    5)   )   �� $ RequiredDate��� 5*      $��Shipped Date��6)   $	 120��5+   )    5,   )   �� $ ShippedDate��� 5-      $��Frieght��6)   $ 70��5.   )    5/   )   �� $ Freight�50      52      �� 53      
����ح�$ Vertical=�54      $
��Left=�55      $	��200��56      .+�57      �� -   5        $��lbTitle2��57      
���  ��$��DemiBold"�59      $��20(�5:      $��Order Detail��5;      �� 5<      -   5        $��lbMemberId2��5<      $��	Member Id��5=      �� 5>      -   5        $��txtMemberId2��5>      $��Stretch=�5?      $��25��5@       �� 
IsReadOnly$
 True��5B      ��5A      �� $ MemberId� �� Mode$ OneWay=�5B      �� 5C      -   5        $��lbProductId2��5C      $��
Product Id��5D      �� 5E      -   5        $��txtProductId2��5E      $��Stretch=�5F      $��25��5G      $
 True��5I      ��5H      �� $ 	ProductId�$ OneWay=�5I      �� 5J      -   5        $��ProductItems��5L      	 �� DisplayMemberPath$	 ProductName��5J      
 �� SelectedValuePath$
 	ProductId��5K       �� SelectedValue 5M      �� $ 	ProductId�$ TwoWay=�5N      �� 5O      -   5        $��
lbQuantity��5O      $��Quantity��5P      �� 5Q      -	   5        $��txtQuantity��5Q      $��Stretch=�5R      $��25��5S      ��5T      �� $ Quantity�$ OneWay=��� 5U      -
   5        $��
lbDiscount��5U      $��Discount��5V      �� 5W      -   5        $��txtDiscount��5W      $��Stretch=�5X      $��25��5Y      ��5Z      �� $ Discount�$ OneWay=��� 5[      -   5        $��lbUnitPrice��5[      $��
Unit Price��5\      �� 5]      -   5        $��txtUnitPrice��5]      $��Stretch=�5^      $��25��5_      ��5`      �� $ 	UnitPrice�$ OneWay=�5b      5c      �� 5e   
   
����ح�$ Vertical=�5f      $
��Left=�5g      $	��300��5h      .+�5i      �� -   5        $��lbTitle��5i      
���  ��$��DemiBold"�5k      $��20(�5l      $��Member Information��5m      �� 5n      -   5        $��
lbMemberId��5n      $��	Member Id��5o      �� 5p      -   5        $��txtMemberId��5p      $��Stretch=�5q      $��25��5r      ��5s      �� $ MemberId�$ OneWay=��� 5t      -   5        $��lbEmail��5t      $��Email��5u      �� 5v      -   5        $��txtEmail��5v      $��Stretch=�5w      $��25��5x      ��5y      �� $ Email�$ OneWay=��� 5z      -   5        $��lbCompanyName��5z      $��Company Name��5{      �� 5|      -   5        $��txtCompanyName��5|      $��Stretch=�5}      $��25��5~      ��5      �� $ CompanyName�$ OneWay=��� 5�      -   5        $��lbCity��5�      $
��City��5�      �� 5�      -   5        $��txtCity��5�      $��Stretch=�5�      $��25��5�      ��5�      �� $
 City�$ OneWay=��� 5�      -   5        $��	lbCountry��5�      $��Country��5�      �� 5�      -   5        $��
txtCountry��5�      $��Stretch=�5�      $��25��5�      ��5�      �� $ Country�$ OneWay=��� 5�      -   5        $��
lbPassword��5�      $��Password��5�      �� 5�      -   5        $��txtPassword��5�      $��Stretch=�5�      $��25��5�      ��5�      �� $ Password�$ OneWay=�5�      �� 5�   
   $��1��6   $ 
Horizontal=�5�      $
��Left=�5�      $��50��5�      .+�5�      �� -   5         ��Name$ 	btnUpdate��5�      $��10q�5�      $��80��5�      $��Update��5�      5�      �� 5�      -   5        $ btnBack��5�      $��10q�5�      $��80��5�      $
��Back��5�      5�      5�      5�      5�      