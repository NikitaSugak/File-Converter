   M S B A M L   `   `   `  ����H  DFileConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FileConverterFileConverter  5   	       FileConverter.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:FileConverter     5   	   -   5          � Title$  File converter��5   	   $	��450��6    $	��400��6-    � WindowStartupLocation$ CenterScreen=�69   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   o� $��20��6   $	��Top=�6   
�������.@�5      m� $
��File��6   .@�5      m� -   5        $��	Open File��5      6M   �� 5      m� 5      -   5        $
��Exit��5      6B   5      5      	� 5   
   -   5         	�Name$ RegularExpression��5       	� 	GroupName$ Recognition��61   $��RegularExpression��6I   $
��Left=�6e   $��	80,90,0,0q�6�   $	��Top=�6�   ${�False��6�   $��15��6�   $	��120��6�   	� 5   
   -   5        $ XmlDocument��5      $ Recognition��6+   $��XmlDocument��6C   $
��Left=�6Y   $��
80,110,0,0q�6t   $	��Top=�6�   ${�False��6�   $��15��6�   $	��120��6�   �� 5   
   -   5         ��Name$ 	Recognize��5      $��	Recognize��6$   $
��Left=�68   $��
90,130,0,0q�6S   $	��Top=�6g   $��30��6   $��90��6�   ${�False��6�   6�   	� 5   
   -   5        $ Excel��5      $��Excel (.xlsx)��6%   $ 
Conversion��6=   $
��Left=�6T   $��
80,190,0,0q�6o   $	��Top=�6�   ${�False��6�   $��15��6�   $	��120��6�   	� 5   
   -   5        $
 Word��5      $��Word (.docx)��6$   $ 
Conversion��6;   $
��Left=�6R   $��
80,210,0,0q�6m   $	��Top=�6�   ${�False��6�   $��15��6�   $	��120��6�   	� 5   
   -	   5        $
 Text��5      $��Text (.txt)��6$   $ 
Conversion��6;   $
��Left=�6R   $��
80,230,0,0q�6m   $	��Top=�6�   ${�False��6�   $��15��6�   $	��120��6�   �� 5   
   -
   5        $
 Save��5      $
��Save��6   $
��Left=�6.   $��
90,250,0,0q�6I   $	��Top=�6]   $��30��6u   $��90��6�   ${�False��6�   5      5      